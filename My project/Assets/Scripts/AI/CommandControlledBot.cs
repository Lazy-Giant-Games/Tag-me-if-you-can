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
    private void Awake() {
        aiMovement = GetComponent<AIMovement>();
    }
    private void Start() {
        m_AIPlayer = GetComponent<NavMeshAgent>();
        StartPlay();
    }
    private void Update() {
        ProcessCommands();
    }

    public void StartPlay() {
        //GameManager.Instance.OnPlayClicked -= StartPlay;
        //StartAcceptingRandomCommand();
        AddMoveCommand(nodeTraverser.runningNodes[0].position);
        AddJumpCommand(nodeTraverser.jumpingNodes[0].position, nodeTraverser.jumpingNodes[1].position);
        AddMoveCommand(nodeTraverser.runningNodes[1].position);
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
    public void AddMoveCommand(Vector3 p_destination, float p_checkDistance = 1f) {
        MoveCommand mc = new MoveCommand(p_destination, m_AIPlayer, this, p_checkDistance);
        m_commands.Enqueue(mc);
    }

    public void AddJumpCommand(Vector3 p_startingPoint, Vector3 p_destinationPoint, float p_checkDistance = 1f) {
        JumpCommand mc = new JumpCommand(p_startingPoint, p_destinationPoint, m_AIPlayer, this, p_checkDistance);
        m_commands.Enqueue(mc);
    }
}
internal class MoveCommand : Command {
    private Vector3 m_destination;
    private readonly NavMeshAgent m_character;
    private readonly CommandControlledBot m_ccb;
    private float m_checkDistance;
    private AIMovement m_aiMovement;
    public MoveCommand(Vector3 p_destination, NavMeshAgent m_mover, CommandControlledBot p_ccb, float p_checkDistance) {
        m_ccb = p_ccb;
        m_destination = p_destination;
        m_character = m_mover;
        m_aiMovement = p_ccb.GetComponent<AIMovement>();
        m_checkDistance = p_checkDistance;
        //m_character.Warp(m_character.transform.position);
    }
    public override void Execute() {
        m_aiMovement.animator.PlayRun();
        m_aiMovement.StartCoroutine(Move());
    }

    IEnumerator Move() {
        Quaternion lookRotation = Quaternion.LookRotation((m_destination - m_aiMovement.transform.position).normalized);
        while (Vector3.Distance(m_character.transform.position, m_destination) > m_checkDistance) {
            m_aiMovement.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, lookRotation, Time.deltaTime * 10f);

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
        m_aiMovement.animator.PlayHighJump();
        m_aiMovement.StartCoroutine(Move());
    }

    IEnumerator Move() {
        m_aiMovement.transform.LookAt(m_destinationPoint, m_aiMovement.transform.up);
        while (Vector3.Distance(m_character.transform.position, m_destinationPoint) > m_checkDistance) {
            //m_aiMovement.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, lookRotation, Time.deltaTime * 90f);

            //instant
            //m_aiMovement.transform.rotation = lookRotation;
            //m_aiMovement.transform.LookAt(m_destination, m_aiMovement.transform.up);
            m_character.transform.position = Vector3.MoveTowards(m_character.transform.position, m_destinationPoint, m_aiMovement.moveSpeed * Time.deltaTime);
            yield return 0;
        }
        m_aiMovement.animator.PlayRoll();
    }
    public override bool IsFinished => Vector3.Distance(m_character.transform.position, m_startingPoint) <= m_checkDistance || m_aiMovement.IsCaptured;
    public override void PrematurelyFinish() { m_character.isStopped = true; }
}