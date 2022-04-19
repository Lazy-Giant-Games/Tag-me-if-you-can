using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
public class CommandControlledBot : MonoBehaviour {

    private NavMeshAgent m_AIPlayer;
    private Queue<Command> m_commands = new Queue<Command>();
    private Command m_currentCommand;
    private bool m_dontAcceptCommand;
    public AIMovement aiMovement;

    public NodeTraverser nodeTraverser;
    private float m_initialSpeed;
    public bool StartedRunning { set; get; }
    private void Awake() {
        aiMovement = GetComponent<AIMovement>();
        m_AIPlayer = GetComponent<NavMeshAgent>();
        m_initialSpeed = aiMovement.moveSpeed;
        aiMovement.moveSpeed /= 2f;
    }
    private void Start() {
        StartCoroutine(IncreaseSpeedInterval());
    }

    IEnumerator IncreaseSpeedInterval() {
        yield return new WaitForSeconds(3f);
        aiMovement.moveSpeed += 5f;
        yield return new WaitForSeconds(1f);
        aiMovement.moveSpeed = m_initialSpeed;
    }
    private void Update() {
        ProcessCommands();
    }

    
    public void StartPlay() {
        if (nodeTraverser.targetPath == NodeTraverser.PATH.RIGHT_PATH) {
            SetPathNode_2();
        } else {
            SetPathNode_1();
        }
        
        StartedRunning = true;
    }

    public void SetPathNode_2() {
        AddMoveCommand(nodeTraverser.runningNodes_b[0].position);
        AddJumpCommand(nodeTraverser.jumpingNodes_b[0].position, nodeTraverser.jumpingNodes_b[1].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[1].position);

        AddJumpCommand(nodeTraverser.jumpingNodes_b[2].position, nodeTraverser.jumpingNodes_b[3].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[2].position, 1f);
        AddJumpCommand(nodeTraverser.jumpingNodes_b[4].position, nodeTraverser.jumpingNodes_b[5].position);

        AddMoveCommand(nodeTraverser.runningNodes_b[3].position, 1f);

        ////AddClimbCommand(nodeTraverser.climbingNodes_b[0].position, nodeTraverser.climbingNodes_b[1].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[4].position, 1f);
        ////AddClimbCommand(nodeTraverser.climbingNodes_b[2].position, nodeTraverser.climbingNodes_b[3].position);
        AddJumpCommand(nodeTraverser.jumpingNodes_b[6].position, nodeTraverser.jumpingNodes_b[7].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[5].position, 1f);
        AddJumpCommand(nodeTraverser.jumpingNodes_b[8].position, nodeTraverser.jumpingNodes_b[9].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[6].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[7].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[8].position, 1f);
        AddMoveCommand(nodeTraverser.runningNodes_b[9].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[10].position, 1f);
        AddMoveCommand(nodeTraverser.runningNodes_b[11].position);
        AddJumpCommand(nodeTraverser.jumpingNodes_b[10].position, nodeTraverser.jumpingNodes_b[11].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[12].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[13].position, 1f);
        AddJumpCommand(nodeTraverser.jumpingNodes_b[12].position, nodeTraverser.jumpingNodes_b[13].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[14].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[15].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[16].position, - 1f);
        
        AddVaultCommand(nodeTraverser.vaultNodes_b[0].position, nodeTraverser.vaultNodes_b[1].position, nodeTraverser.vaultNodes_b[2].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[17].position, 0.85f);
        AddMoveCommand(nodeTraverser.runningNodes_b[18].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[19].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[20].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[21].position);
        AddVaultCommand(nodeTraverser.vaultNodes_b[3].position, nodeTraverser.vaultNodes_b[4].position, nodeTraverser.vaultNodes_b[5].position);
        AddMoveCommand(nodeTraverser.runningNodes_b[22].position, 1.3f);
        AddMoveCommand(nodeTraverser.runningNodes_b[23].position, 1.25f);
        /*
        
        
        //
        
        */
    }

    public void SetPathNode_1() {
        //GameManager.Instance.OnPlayClicked -= StartPlay;
        //StartAcceptingRandomCommand();
        AddMoveCommand(nodeTraverser.runningNodes[0].position);
        AddJumpCommand(nodeTraverser.jumpingNodes[0].position, nodeTraverser.jumpingNodes[1].position);
        AddMoveCommand(nodeTraverser.runningNodes[1].position);

        AddJumpCommand(nodeTraverser.jumpingNodes[2].position, nodeTraverser.jumpingNodes[3].position);
        AddMoveCommand(nodeTraverser.runningNodes[2].position, 1f);
        AddJumpCommand(nodeTraverser.jumpingNodes[4].position, nodeTraverser.jumpingNodes[5].position);

        AddMoveCommand(nodeTraverser.runningNodes[3].position, 1f);

        ////AddClimbCommand(nodeTraverser.climbingNodes[0].position, nodeTraverser.climbingNodes[1].position);
        AddMoveCommand(nodeTraverser.runningNodes[4].position, 1f);
        ////AddClimbCommand(nodeTraverser.climbingNodes[2].position, nodeTraverser.climbingNodes[3].position);
        AddJumpCommand(nodeTraverser.jumpingNodes[6].position, nodeTraverser.jumpingNodes[7].position);
        AddMoveCommand(nodeTraverser.runningNodes[5].position, 1f);
        AddJumpCommand(nodeTraverser.jumpingNodes[8].position, nodeTraverser.jumpingNodes[9].position);
        AddMoveCommand(nodeTraverser.runningNodes[6].position);
        AddMoveCommand(nodeTraverser.runningNodes[7].position);
        AddMoveCommand(nodeTraverser.runningNodes[8].position, 1f);
        AddMoveCommand(nodeTraverser.runningNodes[9].position);
        AddJumpCommand(nodeTraverser.jumpingNodes[10].position, nodeTraverser.jumpingNodes[11].position);
        AddMoveCommand(nodeTraverser.runningNodes[10].position, 1f);

        AddJumpCommand(nodeTraverser.jumpingNodes[12].position, nodeTraverser.jumpingNodes[13].position);
        AddMoveCommand(nodeTraverser.runningNodes[11].position);
        AddJumpCommand(nodeTraverser.jumpingNodes[14].position, nodeTraverser.jumpingNodes[15].position);
        AddMoveCommand(nodeTraverser.runningNodes[12].position);
        AddMoveCommand(nodeTraverser.runningNodes[13].position, 1f);
        AddMoveCommand(nodeTraverser.runningNodes[14].position);
        AddJumpCommand(nodeTraverser.jumpingNodes[16].position, nodeTraverser.jumpingNodes[17].position);
        AddMoveCommand(nodeTraverser.runningNodes[15].position);
        AddMoveCommand(nodeTraverser.runningNodes[16].position);
        AddMoveCommand(nodeTraverser.runningNodes[17].position);
        AddVaultCommand(nodeTraverser.vaultNodes[0].position, nodeTraverser.vaultNodes[1].position, nodeTraverser.vaultNodes[2].position);
        AddMoveCommand(nodeTraverser.runningNodes[18].position);
        AddMoveCommand(nodeTraverser.runningNodes[19].position);
        AddMoveCommand(nodeTraverser.runningNodes[20].position);
        AddMoveCommand(nodeTraverser.runningNodes[21].position);
        AddMoveCommand(nodeTraverser.runningNodes[22].position, 0.5f);
        AddMoveCommand(nodeTraverser.runningNodes[23].position);
        AddVaultCommand(nodeTraverser.vaultNodes[3].position, nodeTraverser.vaultNodes[4].position, nodeTraverser.vaultNodes[5].position);
        AddMoveCommand(nodeTraverser.runningNodes[24].position, 0.5f);
        AddMoveCommand(nodeTraverser.runningNodes[25].position);

        StartedRunning = true;
    }
    private void ProcessCommands() {
        if (m_currentCommand != null && m_currentCommand.IsFinished == false) {
            return;
        }

        if (m_commands.Any() == false) {
            return;
        }

        m_currentCommand = m_commands.Dequeue();
        m_currentCommand.Execute();
        
    }

    public void ClearAllCommand() {
        m_dontAcceptCommand = true;
        StopAllCoroutines();
        //StopCoroutine("AddRandomCommand");
        foreach (Command c in m_commands) {
            c.PrematurelyFinish();
        }
        m_commands.Clear();
        m_currentCommand = null;
    }

    public void StartAcceptingRandomCommand() {
        m_dontAcceptCommand = false;
        StopCoroutine("AddRandomCommand");
        StartCoroutine("AddRandomCommand");
    }
    public void AddMoveCommand(Vector3 p_destination, float p_speedReducer = 0f, float p_checkDistance = 1f) {
        MoveCommand mc = new MoveCommand(p_destination, m_AIPlayer, this, p_checkDistance, p_speedReducer);
        m_commands.Enqueue(mc);
    }

    public void AddJumpCommand(Vector3 p_startingPoint, Vector3 p_destinationPoint, float p_checkDistance = 1f) {
        JumpCommand mc = new JumpCommand(p_startingPoint, p_destinationPoint, m_AIPlayer, this, p_checkDistance);
        m_commands.Enqueue(mc);
    }

    public void AddClimbCommand(Vector3 p_startingPoint, Vector3 p_destinationPoint, float p_checkDistance = 1f) {
        ClimbCommand mc = new ClimbCommand(p_startingPoint, p_destinationPoint, m_AIPlayer, this, p_checkDistance);
        m_commands.Enqueue(mc);
    }

    public void AddVaultCommand(Vector3 p_startingPoint, Vector3 p_midPoint, Vector3 p_destinationPoint, float p_checkDistance = 1f) {
        VaultCommand mc = new VaultCommand(p_startingPoint, p_midPoint, p_destinationPoint, m_AIPlayer, this, p_checkDistance);
        m_commands.Enqueue(mc);
    }
}
internal class MoveCommand : Command {
    private Vector3 m_destination;
    private readonly NavMeshAgent m_character;
    private readonly CommandControlledBot m_ccb;
    private float m_checkDistance;
    private AIMovement m_aiMovement;
    private float m_speedReducer;
    public MoveCommand(Vector3 p_destination, NavMeshAgent m_mover, CommandControlledBot p_ccb, float p_checkDistance, float p_speedReducer = 0f) {
        m_ccb = p_ccb;
        m_destination = p_destination;
        m_character = m_mover;
        m_aiMovement = p_ccb.GetComponent<AIMovement>();
        m_checkDistance = p_checkDistance;
        m_speedReducer = p_speedReducer; ;
        //m_character.Warp(m_character.transform.position);
    }
    public override void Execute() {
        if (m_aiMovement.IsCaptured) {
            m_aiMovement.moveSpeed = 0f;
            return;
        }
        m_aiMovement.ReduceSpeed(m_speedReducer);
        //Debug.LogError("Do Run");
        m_aiMovement.animator.PlayRun();
        m_aiMovement.StartCoroutine(Move());
    }

    IEnumerator Move() {
        //Quaternion lookRotation = Quaternion.LookRotation((m_destination - m_aiMovement.transform.position).normalized);
        m_aiMovement.transform.LookAt(m_destination, m_aiMovement.transform.up);
        while (Vector3.Distance(m_character.transform.position, m_destination) > m_checkDistance && !m_aiMovement.IsCaptured) {
            //m_aiMovement.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, lookRotation, Time.deltaTime * 10f);

            //instant
            //m_aiMovement.transform.rotation = lookRotation;
            //m_aiMovement.transform.LookAt(m_destination, m_aiMovement.transform.up);
            m_character.transform.position = Vector3.MoveTowards(m_character.transform.position, m_destination, m_aiMovement.moveSpeed * Time.deltaTime);
            yield return 0;
        }
    }
    public override bool IsFinished => Vector3.Distance(m_character.transform.position, m_destination) <= m_checkDistance || m_aiMovement.IsCaptured;
    public override void PrematurelyFinish() { m_character.isStopped = true; }
}

internal class JumpCommand : Command {
    private Vector3 m_startingPoint;
    private Vector3 m_destinationPoint;
    private readonly NavMeshAgent m_character;
    private readonly CommandControlledBot m_ccb;
    private float m_checkDistance;
    private AIMovement m_aiMovement;
    public JumpCommand(Vector3 p_startingPoint, Vector3 p_destinationPoint, NavMeshAgent m_mover, CommandControlledBot p_ccb, float p_checkDistance = 0.5f) {
        m_ccb = p_ccb;
        m_startingPoint = p_startingPoint;
        m_destinationPoint = p_destinationPoint;
        m_character = m_mover;
        m_aiMovement = p_ccb.GetComponent<AIMovement>();
        m_checkDistance = p_checkDistance;
        //m_character.Warp(m_character.transform.position);
    }
    public override void Execute() {
        if (m_aiMovement.IsCaptured) {
            m_aiMovement.moveSpeed = 0f;
            return;
        }
        m_aiMovement.ReduceSpeed();
        m_aiMovement.animator.PlayHighJump();
        m_aiMovement.StartCoroutine(Jump());
    }

    IEnumerator Jump() {
        m_character.transform.position = m_startingPoint;
        //m_aiMovement.transform.LookAt(m_destinationPoint, m_aiMovement.transform.up);
        while (Vector3.Distance(m_character.transform.position, m_destinationPoint) > m_checkDistance) {
            //m_aiMovement.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, lookRotation, Time.deltaTime * 90f);

            //instant
            //m_aiMovement.transform.rotation = lookRotation;
            //m_aiMovement.transform.LookAt(m_destination, m_aiMovement.transform.up);
            m_character.transform.position = Vector3.MoveTowards(m_character.transform.position, m_destinationPoint, (m_aiMovement.moveSpeed / 1.5f) * Time.deltaTime);
            yield return 0;
        }
        m_aiMovement.animator.PlayRoll();
    }
    public override bool IsFinished => Vector3.Distance(m_character.transform.position, m_destinationPoint) <= m_checkDistance || m_aiMovement.IsCaptured;
    public override void PrematurelyFinish() { m_character.isStopped = true; }
}
internal class ClimbCommand : Command {
    private Vector3 m_startingPoint;
    private Vector3 m_destinationPoint;
    private readonly NavMeshAgent m_character;
    private readonly CommandControlledBot m_ccb;
    private float m_checkDistance;
    private AIMovement m_aiMovement;
    public ClimbCommand(Vector3 p_startingPoint, Vector3 p_destinationPoint, NavMeshAgent m_mover, CommandControlledBot p_ccb, float p_checkDistance = 0.5f) {
        m_ccb = p_ccb;
        m_startingPoint = p_startingPoint;
        m_destinationPoint = p_destinationPoint;
        m_character = m_mover;
        m_aiMovement = p_ccb.GetComponent<AIMovement>();
        m_checkDistance = p_checkDistance;
        //m_character.Warp(m_character.transform.position);
    }
    public override void Execute() {
        if (m_aiMovement.IsCaptured) {
            m_aiMovement.moveSpeed = 0f;
            return;
        }
        m_aiMovement.animator.PlayHighJump();
        m_aiMovement.StartCoroutine(Jump());
    }

    IEnumerator Jump() {
        m_aiMovement.ReduceSpeed();
        m_character.transform.position = m_startingPoint;
        //m_aiMovement.transform.LookAt(m_destinationPoint, m_aiMovement.transform.up);
        m_aiMovement.animator.PlayClimb();
        while (Vector3.Distance(m_character.transform.position, m_destinationPoint) > m_checkDistance) {
            //m_aiMovement.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, lookRotation, Time.deltaTime * 90f);

            //instant
            //m_aiMovement.transform.rotation = lookRotation;
            //m_aiMovement.transform.LookAt(m_destination, m_aiMovement.transform.up);
            m_character.transform.position = Vector3.MoveTowards(m_character.transform.position, m_destinationPoint, m_aiMovement.moveSpeed * Time.deltaTime);
            yield return 0;
        }
        m_aiMovement.animator.PlayClimbExit();
    }
    public override bool IsFinished => Vector3.Distance(m_character.transform.position, m_destinationPoint) <= m_checkDistance || m_aiMovement.IsCaptured;
    public override void PrematurelyFinish() { m_character.isStopped = true; }
}

internal class VaultCommand : Command {
    private Vector3 m_startingPoint;
    private Vector3 m_midPoint;
    private Vector3 m_destinationPoint;
    private readonly NavMeshAgent m_character;
    private readonly CommandControlledBot m_ccb;
    private float m_checkDistance;
    private AIMovement m_aiMovement;

    private bool m_isFinished = false;
    public VaultCommand(Vector3 p_startingPoint, Vector3 p_midPoint, Vector3 p_destinationPoint, NavMeshAgent m_mover, CommandControlledBot p_ccb, float p_checkDistance = 0.5f) {
        m_ccb = p_ccb;
        m_startingPoint = p_startingPoint;
        m_midPoint = p_midPoint;
        m_destinationPoint = p_destinationPoint;
        m_character = m_mover;
        m_aiMovement = p_ccb.GetComponent<AIMovement>();
        m_checkDistance = p_checkDistance;
        //m_character.Warp(m_character.transform.position);
    }
    public override void Execute() {
        if (m_aiMovement.IsCaptured) {
            m_aiMovement.moveSpeed = 0f;
            return;
        }
        Vault();
    }

    void Vault() {
        m_aiMovement.ReduceSpeed();
        m_character.transform.position = m_startingPoint;
        //m_aiMovement.transform.LookAt(m_destinationPoint, m_aiMovement.transform.up);
        m_aiMovement.animator.PlayVault();
        LeanTween.move(m_aiMovement.gameObject, m_startingPoint, 0f).setOnComplete(() => LeanTween.move(m_aiMovement.gameObject, m_midPoint, 0.5f).setOnComplete(() => LeanTween.move(m_aiMovement.gameObject, m_destinationPoint, 0.5f).setOnComplete(() => m_isFinished = true)));

    }
    public override bool IsFinished => m_isFinished || m_aiMovement.IsCaptured;
    public override void PrematurelyFinish() { m_character.isStopped = true; }
}