using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //static (stays same) quest manager instance
    public static QuestManager instance;

    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //test
        ApplyQuestData(GetQuest("testQuest"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //load a quest from JSON and return the resulting object
    public Quest GetQuest(string QuestJSON)
    {
        //get json from resources
        
        string filePath = "Quests/" + QuestJSON;
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        //create and override json
        Quest loadedQuest = new Quest();
        JsonUtility.FromJsonOverwrite(jsonFile.text, loadedQuest);

        return loadedQuest;
    }

    //applies quest data to a quest object instance
    public void ApplyQuestData(Quest questData)
    {
        //get quest compenent
        Quest applyToQuest = GetComponent<Quest>();

        //set variables
        applyToQuest.questName = questData.questName;
        applyToQuest.description = questData.description;
    }


}
