using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerDragHandler : MonoBehaviour
{

    public GameObject lightTower, heavyTower, superHeavyTower;
    public static bool holdingTower;
    private GameObject tower;
    private int tempGoldMissing;

    public GameController gc;

    public Sprite lightTowerSprite, heavyTowerSprite, superHeavyTowerSprite;
    private Texture2D cursorTextureLight, cursorTextureHeavy, cursorTextureSuperHeavy;
    private CursorMode cursMode = CursorMode.Auto;
    private Vector2 vect2 = Vector2.zero;
    public void Start()
    {
        gc = FindObjectOfType<GameController>();
        cursorTextureLight = SpriteToTexture(lightTowerSprite);
        cursorTextureHeavy = SpriteToTexture(heavyTowerSprite);
        cursorTextureSuperHeavy = SpriteToTexture(superHeavyTowerSprite);
    }

    private Texture2D SpriteToTexture(Sprite sprite)
    {
        var croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        return croppedTexture;
    }

    public void setTower(int type)
    {
        if (!holdingTower)
        {
            Debug.Log(gc.money);
            if (type == 0 && gc.money >= 40)
            {
                //if you have enough gold then do this stuff otherwise nothing (LIGHT TOWER)
                tempGoldMissing = 40;
                
                tower = lightTower;
                Cursor.SetCursor(cursorTextureLight, vect2, cursMode);
                holdingTower = true;
            }
            else if (type == 1 && gc.money >= 100)
            {
                tempGoldMissing = 100;
                //if you have enough gold then do this stuff otherwise nothing (HEAVY TOWER)
                //tempGoldMissing = **Tower cost
                tower = heavyTower;
                Cursor.SetCursor(cursorTextureHeavy, vect2, cursMode);
                holdingTower = true;
            }
            else if (type == 2 && gc.money >= 160)
            {
                //if you have enough gold then do this stuff otherwise nothing (LAZER TOWER)
                //tempGoldMissing = **Tower cost

                tempGoldMissing = 160;
                tower = superHeavyTower;
                Cursor.SetCursor(cursorTextureSuperHeavy, vect2, cursMode);
                holdingTower = true;
            }
            
        }
    }

    public void Update()
    {

        if(holdingTower)
        {
            if(Input.GetMouseButtonDown(0))
            {
                gc.money -= tempGoldMissing;
                tempGoldMissing = 0;
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousepos = new Vector3(mousepos.x, mousepos.y, 1);
                Instantiate(tower, mousepos, Quaternion.identity);             
                holdingTower = false;
                Cursor.SetCursor(null, vect2, cursMode);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                tempGoldMissing = 0;
                holdingTower = false;
                Cursor.SetCursor(null, vect2, cursMode);
            }
        }
    }

}
