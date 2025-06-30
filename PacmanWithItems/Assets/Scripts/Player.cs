using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    // Opcjonalnie: Zablokuj tworzenie wielu instancji
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Usuwa duplikat
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Utrzymaj między scenami (opcjonalne)

        //  Ustaw limit FPS
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // Wyłączenie vSync, żeby targetFrameRate działał niezależnie

        rb = GetComponent<Rigidbody>();
    }


    public Item heldItem;

    Rigidbody rb;
    private Vector3 inputDirection;

    public float moveSpeed = 5f;

    void DropHeldItem()
    {
        if (heldItem != null)
        {
            var puppet = Instantiate(heldItem.puppetPrefab, transform.position + Vector3.forward, Quaternion.identity);
            puppet.transform.position = new Vector3(puppet.transform.position.x, 0, puppet.transform.position.z);
            Destroy(heldItem.gameObject);
            //puppet.GetComponent<ItemPuppet>().item = heldItem;
        }
    }

    public void PickUpItem(Item newItem)
    {
        DropHeldItem();
        heldItem = newItem;
    }

    void Update()
    {
        // Pobierz wartości wejścia z klawiatury (WASD)
        float moveX = Input.GetAxisRaw("Horizontal"); // A (-1) i D (1)
        float moveZ = Input.GetAxisRaw("Vertical");   // W (1) i S (-1)

        // Normalizuj kierunek, by uniknąć szybszego poruszania po skosie
        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (Input.GetKeyDown(KeyCode.E) && heldItem != null)
        {
            heldItem.Use();
        }

        // Wyłącz aplikację ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Działa w buildzie

        }

    }
    


    private void FixedUpdate()
    {
        rb.velocity = inputDirection * moveSpeed + new Vector3(0f, rb.velocity.y, 0f);

        if (inputDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            rb.MoveRotation(targetRotation);
        }
    }
}
