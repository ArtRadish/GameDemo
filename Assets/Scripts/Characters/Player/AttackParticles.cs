using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackParticles : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;
    [SerializeField] private List<Transform> transforms;
    public void CreateAttack01()
    {
        int n = 0;
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n],transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }
    public void CreateAttack02()
    {
        int n = 1;
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n], transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }
    public void CreateAttack03()
    {
        int n = 2;
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n], transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }
    public void CreateAttack04()
    {
        int n = 3;
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n], transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }

    public void CreateFlyingKick()
    {
        int n = 4;
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n], transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }

    public void CreateFlip()
    {
        int n = Random.Range(5, 7);
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n], transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }

    public void CreateRuntoFlip()
    {
        int n = 7;
        if (gameObjects.Count <= n || transforms.Count <= n)
            return;
        var obj = Instantiate(gameObjects[n], transform);
        obj.transform.position = transforms[n].position;
        obj.transform.parent = null;
        transforms[n].GetComponent<ShowAttackCheck>().StartCheck();
    }
}
