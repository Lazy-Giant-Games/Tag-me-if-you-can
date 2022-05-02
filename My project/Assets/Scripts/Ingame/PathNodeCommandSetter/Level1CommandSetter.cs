using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1CommandSetter : PathNodeCommandSetter {
    #region per level pathnodes setup
    public override void SetPathNodeRight() {
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[0].position, 2f);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[0].position, nodeTraverser.jumpingNodes_b[1].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[1].position, 0.75f);

        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[2].position, nodeTraverser.jumpingNodes_b[3].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[2].position, 0.75f);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[4].position, nodeTraverser.jumpingNodes_b[5].position);

        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[3].position, 0.25f);

        ////AddClimbCommand(nodeTraverser.climbingNodes_b[0].position, nodeTraverser.climbingNodes_b[1].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[4].position, 0.25f);
        ////AddClimbCommand(nodeTraverser.climbingNodes_b[2].position, nodeTraverser.climbingNodes_b[3].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[6].position, nodeTraverser.jumpingNodes_b[7].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[5].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[8].position, nodeTraverser.jumpingNodes_b[9].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[6].position, 0.25f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[7].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[8].position, 0.25f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[9].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[10].position, 0.25f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[11].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[10].position, nodeTraverser.jumpingNodes_b[11].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[12].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[13].position, 0.5f);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes_b[12].position, nodeTraverser.jumpingNodes_b[13].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[14].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[15].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[16].position, -0.75f);

        commandControlledBot.AddVaultCommand(nodeTraverser.vaultNodes_b[0].position, nodeTraverser.vaultNodes_b[1].position, nodeTraverser.vaultNodes_b[2].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[17].position, 1.5f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[18].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[19].position, 0.75f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[20].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[21].position);
        commandControlledBot.AddVaultCommand(nodeTraverser.vaultNodes_b[3].position, nodeTraverser.vaultNodes_b[4].position, nodeTraverser.vaultNodes_b[5].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[22].position, 1f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes_b[23].position, 1.25f);
    }
    public override void SetPathNodeLeft() {
        //GameManager.Instance.OnPlayClicked -= StartPlay;
        //StartAcceptingRandomCommand();
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[0].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[0].position, nodeTraverser.jumpingNodes[1].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[1].position, 1f);

        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[2].position, nodeTraverser.jumpingNodes[3].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[2].position, 1f);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[4].position, nodeTraverser.jumpingNodes[5].position);

        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[3].position, 1f);

        ////AddClimbCommand(nodeTraverser.climbingNodes[0].position, nodeTraverser.climbingNodes[1].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[4].position, 1f);
        ////AddClimbCommand(nodeTraverser.climbingNodes[2].position, nodeTraverser.climbingNodes[3].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[6].position, nodeTraverser.jumpingNodes[7].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[5].position, 1.5f);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[8].position, nodeTraverser.jumpingNodes[9].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[6].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[7].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[8].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[9].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[10].position, nodeTraverser.jumpingNodes[11].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[10].position);

        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[12].position, nodeTraverser.jumpingNodes[13].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[11].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[14].position, nodeTraverser.jumpingNodes[15].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[12].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[13].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[14].position);
        commandControlledBot.AddJumpCommand(nodeTraverser.jumpingNodes[16].position, nodeTraverser.jumpingNodes[17].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[15].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[16].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[17].position);
        commandControlledBot.AddVaultCommand(nodeTraverser.vaultNodes[0].position, nodeTraverser.vaultNodes[1].position, nodeTraverser.vaultNodes[2].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[18].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[19].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[20].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[21].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[22].position, 1.5f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[23].position);
        commandControlledBot.AddVaultCommand(nodeTraverser.vaultNodes[3].position, nodeTraverser.vaultNodes[4].position, nodeTraverser.vaultNodes[5].position);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[24].position, 1.5f);
        commandControlledBot.AddMoveCommand(nodeTraverser.runningNodes[25].position);
    }
    #endregion
}