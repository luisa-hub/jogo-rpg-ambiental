using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page 
{
    public string Title { get; set; }
    public string Text { get; set; }
    public List<string> Pages { get; set; }

    public static List<Page> _pageList = null;
    public static Page RandomPage;

    public int CurrentPage1 = 0;
    public int CurrentPage2 = 1;


    public static Page GetRandomPage()
    {
        List<Page> pageList = Page.PageList;
        int num = UnityEngine.Random.Range(0, pageList.Count);
        Page pge = pageList[num];
        pge.Pages = new List<string>();

        string[] words = pge.Text.Split(' ');

        string page = "";
        int wordCount = 0;

        foreach (var word in words)
        {
            wordCount++;
            if (wordCount > 6)
            {
                pge.Pages.Add(page);
                page = "";
                wordCount = 0;

            }

            page += string.Format("{0}", word);

        }

        pge.Pages.Add(page);
        RandomPage = pge;

        return pge;
    }

    public static List<Page> PageList
    {
        get
            { 
            if(_pageList==null)
            {
                _pageList = new List<Page>();

                _pageList.Add(new Page()
                {
                    Title = "título",
                    Text = "um monte de texto aleatório.........."


                });
                

            }
            return _pageList;



        }
    }

}
