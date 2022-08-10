using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform target_cube;
    private void LateUpdate() {
        /*
        Karakterimizin hemen üstünde bulunan kübü takip edeceğimiz kodu yazdık. 
            Kameranın pozisyonunu, takip ettiği kübün pozisyonuna doğru hareket etmesini istedik ve 
        bunu yaparken zamana bağlı olarak 3f'lik adımlarla ilerliyecek.
        */
        transform.position = Vector3.Lerp(transform.position, target_cube.position, Time.deltaTime*3.0f);  
    }
}
