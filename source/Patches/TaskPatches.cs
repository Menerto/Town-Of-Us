using HarmonyLib;
using UnityEngine;

namespace TownOfUs
{
    internal static class TaskPatches
    {
        [HarmonyPatch(typeof(GameData), nameof(GameData.RecomputeTaskCounts))]
        private class GameData_RecomputeTaskCounts
        {
            private static bool Prefix(GameData __instance)
            {
                __instance.TotalTasks = 0;
                __instance.CompletedTasks = 0;
                for (var i = 0; i < __instance.AllPlayers.Count; i++)
                {
                    var playerInfo = __instance.AllPlayers.ToArray()[i];
                    if (!playerInfo.Disconnected && playerInfo.Tasks != null && playerInfo.Object &&
                        (PlayerControl.GameOptions.GhostsDoTasks || !playerInfo.IsDead) && !playerInfo.IsImpostor &&
                        !(
                            playerInfo._object.Is(RoleEnum.Jester) || playerInfo._object.Is(RoleEnum.Shifter) ||
                            playerInfo._object.Is(RoleEnum.Glitch) || playerInfo._object.Is(RoleEnum.Executioner) ||
                            playerInfo._object.Is(RoleEnum.Arsonist)
                        ))
                        for (var j = 0; j < playerInfo.Tasks.Count; j++)
                        {
                            __instance.TotalTasks++;
                            if (playerInfo.Tasks.ToArray()[j].Complete) __instance.CompletedTasks++;
                        }
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(Console), nameof(Console.CanUse))]
        private class Console_CanUse
        {
            private static bool Prefix(Console __instance, GameData.PlayerInfo __0, out bool __1, out bool __2)
            {
                var num = float.MaxValue;
                var @object = __0.Object;

                var flag = @object.Is(RoleEnum.Glitch) || @object.Is(RoleEnum.Jester) ||
                           @object.Is(RoleEnum.Shifter) || @object.Is(RoleEnum.Executioner) ||
                           @object.Is(RoleEnum.Arsonist);

                var truePosition = @object.GetTruePosition();
                var position = __instance.transform.position;
                __2 = (!__0.IsDead || PlayerControl.GameOptions.GhostsDoTasks && !__instance.GhostsIgnored) &&
                      @object.CanMove &&
                      (__instance.AllowImpostor || !flag && !__0.IsImpostor) &&
                      (!__instance.onlySameRoom || MethodRewrites.InRoom(__instance, truePosition)) &&
                      (!__instance.onlyFromBelow || truePosition.y < position.y) &&
                      MethodRewrites.FindTask(__instance, @object);
                __1 = __2;
                if (__1)
                {
                    num = Vector2.Distance(truePosition, __instance.transform.position);
                    __1 &= num <= __instance.UsableDistance;
                    if (__instance.checkWalls)
                        __1 &= !PhysicsHelpers.AnythingBetween(truePosition, position, Constants.ShadowMask, false);
                }

                return false;
            }
        }

        private class MethodRewrites
        {
            public static bool InRoom(Console __instance, Vector2 truePos)
            {
                var plainShipRoom = ShipStatus.Instance.FastRooms[__instance.Room];
                if (!plainShipRoom || !plainShipRoom.roomArea) return false;

                bool result;
                try
                {
                    result = plainShipRoom.roomArea.OverlapPoint(truePos);
                }
                catch
                {
                    result = false;
                }

                return result;
            }

            public static PlayerTask FindTask(Console __instance, PlayerControl pc)
            {
                for (var i = 0; i < pc.myTasks.Count; i++)
                {
                    var playerTask = pc.myTasks.ToArray()[i];
                    if (!playerTask.IsComplete && playerTask.ValidConsole(__instance)) return playerTask;
                }

                return null;
            }
        }
    }
}