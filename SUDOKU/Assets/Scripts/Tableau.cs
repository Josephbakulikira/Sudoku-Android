using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tableau : MonoBehaviour
{
    public GameObject CompletePanel;
    private int[,] playField = new int[9, 9];
    private string field;
    private int[,] PuzzleField = new int[9, 9];
    private int boxToDelete = 35;
    private int maxIndices;

    public enum Difficulties
    {
        TESTING,
        EASY,
        MEDIUM,
        HARD,
        INSANE,
        PRETRE
    }

    public Difficulties difficulty;
    public Transform A1, A2, A3, B1, B2, B3, C1, C2, C3;
    public GameObject buttonPrefab;

    List<numberButton> ButtonList = new List<numberButton>();    



    // Start is called before the first frame update
    void Start()
    {
        CompletePanel.SetActive(false);
        difficulty = (Tableau.Difficulties)Settings.difficulty;

        inboard(ref playField);
        shuffleGrid(ref playField, 1);
        CreateButton();
    }
    
 
        // Method an d all the functions Mechanism
        #region
        void inboard(ref int[,] grid)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
            }
        }
    }

    void printGrid(ref int[,] grid)
    {
        field = "";
        int space = 0;
        for (int i = 0; i < 9; i++)
        {
            field += "|";
            for (int j = 0; j < 9; j++)
            {
                field += grid[i, j].ToString();

                space = j % 3;
                if (space == 2)
                {
                    field += "|";
                }
            }
            field += "\n";

        }
        //print(field);
    }

    void shuffleGrid(ref int[,] grid ,int shuffleNumber)
    {
        for (int i = 0; i < shuffleNumber; i++)
        {
            int firstValue = Random.Range(1, 10);
            int secondValue = Random.Range(1, 10);

            MixTwoValue(ref grid, firstValue, secondValue);
            createPuzzleField();
            
        }
        //printGrid(ref grid);

    }

    void MixTwoValue(ref int[,] grid, int firstValue, int secondValue)
    {
        int x1 = 0, x2 = 0, y1 = 0, y2 = 0;



        for (int i = 0; i < 9; i += 3)
        {
            for (int k = 0; k < 9; k +=3)
            {
                for (int p = 0; p < 3; p++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i+p, k+j] == firstValue)
                        {
                            x1 = i + p;
                            y1 = k + j;
                        }
                        if (grid[i+p, k+j] == secondValue)
                        {
                            x2 = i + p;
                            y2 = k + j;
                        }
                    }
                }
                grid[x1, y1] = secondValue;
                grid[x2, y2] = firstValue;
            }
        }
    }

    void createPuzzleField()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                PuzzleField[i, j] = playField[i, j];
            }
        }
        //concernant les niveaux de difficultes
        setDiffuculty();
        #region

        #endregion
        for (int i = 0; i < boxToDelete; i++)
        {
            int x1 = Random.Range(0, 9);
            int y1 = Random.Range(0, 9);

            while (PuzzleField[x1, y1] == 0)
            {
                 x1 = Random.Range(0, 9);
                 y1 = Random.Range(0, 9);
            }
            PuzzleField[x1, y1] = 0;
        }
        printGrid(ref PuzzleField);
    }


    #endregion

    void CreateButton()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject newButton = Instantiate(buttonPrefab);

                numberButton numField = newButton.GetComponent<numberButton>();
                numField.SetValue(i, j, PuzzleField[i, j], i + "," + j, this);
                newButton.name = i + "," + j;

                if(PuzzleField[i, j] == 0)
                {
                    ButtonList.Add(numField);   
                }

                //A,B,C hanbdler
                #region
                if (i < 3 && j <3)
                {
                    newButton.transform.SetParent(A1, false);
                }
                if (i < 3 && j >2 && j < 6)
                {
                    newButton.transform.SetParent(A2, false);
                }
                if (i < 3 && j > 5)
                {
                    newButton.transform.SetParent(A3, false);
                }

                if (i > 2 && 1 < 6 && j < 3)
                {
                    newButton.transform.SetParent(B1, false);
                }
                if (i > 2 && 1 < 6 && j > 2 && j < 6)
                {
                    newButton.transform.SetParent(B2, false);
                }
                if (i > 2 && 1 < 6 && j > 5)
                {
                    newButton.transform.SetParent(B3, false);
                }

                if (i > 5 && j < 3)
                {
                    newButton.transform.SetParent(C1, false);
                }
                if (i > 5 &&  j > 2 && j < 6)
                {
                    newButton.transform.SetParent(C2, false);
                }
                if (i > 5  && j > 5)
                {
                    newButton.transform.SetParent(C3, false);
                }

                #endregion
            }
        }
    }

    public void SetInputRiddle(int x, int y, int value)
    {
        PuzzleField[x, y] = value;
    }

    void setDiffuculty()
    {
        switch (difficulty)
        {
            case Difficulties.TESTING:
                boxToDelete = 5;
                maxIndices = 3;
                break;
            case Difficulties.EASY:
                boxToDelete = 35;
                maxIndices = 5; 
                break;
            case Difficulties.MEDIUM:
                boxToDelete = 40;
                maxIndices = 6;
                break;
            case Difficulties.HARD:
                boxToDelete = 45;
                maxIndices = 7;
                break;
            case Difficulties.INSANE:
                boxToDelete = 50;
                maxIndices = 8;
                break;
            case Difficulties.PRETRE:
                boxToDelete = 55;
                maxIndices = 10;
                break;
        }
    }

    public void CheckComplete()
    {
        if (checkIfWon())
        {
            //print("completed");
            CompletePanel.SetActive(true);

        }
        else
        {
            //print("try again");
        }
    }

    bool checkIfWon()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (PuzzleField[i, j ] != playField[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void showIndices()
    {
        if (ButtonList.Count > 0 && maxIndices > 0)
        {
            int randomIndex = Random.Range(0, ButtonList.Count);
            maxIndices--;
            PuzzleField[ButtonList[randomIndex].GetX(), ButtonList[randomIndex].GetY()] = playField[ButtonList[randomIndex].GetX(), ButtonList[randomIndex].GetY()];
            ButtonList[randomIndex].SetIndice(PuzzleField[ButtonList[randomIndex].GetX(), ButtonList[randomIndex].GetY()]);

            ButtonList.RemoveAt(randomIndex);
        }
        else
        {
            //print("we're out of indices");
        }
    }
    
}
