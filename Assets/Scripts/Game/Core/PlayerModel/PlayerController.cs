using System;
using Game.Core.GameInteract;
using Game.Core.InputGame;
using UnityEngine;


namespace Game.Core.PlayerModel
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;

        public float speed = 3;
        public float checkRadio;

        private Rigidbody2D m_rb2D;
        private SpriteRenderer m_spriteRenderer;

        private bool m_flipX;
        private bool m_isRun;

        private Vector2 m_moveDir;
        private PlayerAnimatior m_animatior;
        private PlayerInteraction m_interaction;
        private PlayerEvnetor m_eventor;

        private void Awake()
        {
            Instance = this;
            m_interaction = new PlayerInteraction(this);
            m_animatior = new PlayerAnimatior(this);
            m_eventor = new PlayerEvnetor(this);

            m_rb2D = GetComponent<Rigidbody2D>();
            m_spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InitCompontent();
        }


        private void Update()
        {
            m_animatior.SetIsRun(m_isRun);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnDestroy()
        {
            m_eventor.UnListener();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interact"))
            {
                var obInteract = other.transform.GetComponent<GameObjectInteract>();
                if (obInteract)
                {
                    m_interaction.AddInteractList(obInteract);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interact"))
            {
                var obInteract = other.transform.GetComponent<GameObjectInteract>();
                if (obInteract)
                {
                    m_interaction.RemoveInteractList(obInteract);
                }
            }
        }

        private void InitCompontent()
        {
            m_eventor.Listener();
        }

        private void Move()
        {
            m_moveDir = GameInputSystem.Instance.GetMoveVector2Normal();
            m_isRun = m_moveDir != Vector2.zero;
            //DebugLogger.Instance.Log(this,$"{m_moveDir} {m_isRun}");
            m_rb2D.linearVelocity = m_moveDir * speed;
            ControlFlipX(m_moveDir);
        }

        private void ControlFlipX(Vector2 dir)
        {
            if (dir.x == 0)
            {
                return;
            }

            m_flipX = dir.x < 0;
            if (m_flipX)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }
        }

        public void SetHandPoint(GameObject target)
        {
            m_interaction.SetHandPoint(target);
        }
    }
}