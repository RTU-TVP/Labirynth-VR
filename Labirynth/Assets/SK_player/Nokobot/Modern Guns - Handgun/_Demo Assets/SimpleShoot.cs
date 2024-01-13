using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _fire;
    [SerializeField] private AudioClip _reload;
    [SerializeField] private AudioClip _nonFire;

    [Header("Magazine")]
    [SerializeField] private Magazine _magazine;
    [SerializeField] private XRBaseInteractor _socketInteractor;
    [SerializeField] private bool _hasSlide = true;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        _socketInteractor.onSelectEntered.AddListener(AddMagazine);
        _socketInteractor.onSelectExited.AddListener(ReleaseMagazine);
    }


    private void AddMagazine(XRBaseInteractable interactable)
    {
        _magazine = interactable.GetComponent<Magazine>();
        _audioSource.PlayOneShot(_reload);

    }

    public void Slide() { 
        _hasSlide = true;
        _audioSource.PlayOneShot(_reload);
    }

    private void ReleaseMagazine(XRBaseInteractable interactable)
    {
        _magazine = null;
        _hasSlide = false;
        _audioSource.PlayOneShot(_reload);
    }

    public void PullTheTrigger()
    {
        if (_magazine && _magazine.bulletsCount > 0 && _hasSlide)
        {
            gunAnimator.SetTrigger("Fire");
        }
        else { _audioSource.PlayOneShot(_nonFire); }
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        _audioSource.PlayOneShot(_fire);
        _magazine.bulletsCount--;

        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
