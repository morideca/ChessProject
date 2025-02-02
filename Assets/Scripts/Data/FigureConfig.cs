using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "chessConfig/chess")]
public class FigureConfig : ScriptableObject
{
    public GameObject WhiteFigurePrefab => whiteFigurePrefab;
    public GameObject BlackFigurePrefab => blackFigurePrefab;
    public int Health => health;
    public int Damage => damage;
    public int AttackCooldown => attackCooldown;
    public float AttackRange => attackRange;
    public float MoveSpeed => moveSpeed;
    public FigureType FigureType => figureType;
        
    [SerializeField]
    private GameObject whiteFigurePrefab;
    [SerializeField]
    private GameObject blackFigurePrefab;
    [SerializeField] 
    private int health;
    [SerializeField] 
    private int damage;
    [SerializeField]
    private float moveSpeed;
    [SerializeField] 
    private float attackRange;
    [SerializeField] 
    private int attackCooldown;
    [FormerlySerializedAs("chessType")] [SerializeField] 
    private FigureType figureType;
}

