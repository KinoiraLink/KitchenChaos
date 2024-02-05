using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;//RecipeListSO (Recipe List SO)
    private List<RecipeSO> waitingrecipeSOList;

    private float spawnRecipeTimer;

    private float spawnRecipeTimerMax = 4f;

    private int waitingRecipesMax = 4;

    private int successfilRecipesAmount;

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeFailed;
    public event EventHandler OnRecipeSuccess;

    private void Awake()
    {
        Instance = this;

        waitingrecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (KitchenGameManager.Instance.IsGamePlaying() &&waitingrecipeSOList.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingrecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingrecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingrecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                // 合成数量相同
                bool plateContentsMatchesRecipe = true;
                foreach (KitchenObjectSO recipeLitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    // 循环整个菜谱成分
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        // 循环整个盘子成分
                        if (plateKitchenObjectSO == recipeLitchenObjectSO)
                        {
                            // 成分匹配
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        // 菜谱里的成分在盘子中找不到
                        plateContentsMatchesRecipe = false;
                    }
                }
                if (plateContentsMatchesRecipe)
                {
                    // 玩家交付
                    Debug.Log("Player delivered the correct recipe!");
                    successfilRecipesAmount++;
                    waitingrecipeSOList.RemoveAt(i);
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        // 不能匹配
        // 玩家不能交付
        Debug.Log("Player did not deliver a correct recipe");
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }

    public IEnumerable<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingrecipeSOList;
    }

    public int GetSuccessfulRecipesAmount()
    {
        return successfilRecipesAmount;
    }
}
