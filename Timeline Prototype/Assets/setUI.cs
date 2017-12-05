using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setUI : MonoBehaviour {

    public Text title;
    public Text date;
    public Text description;
    public Image image;
    public Sprite edwidge;
    public Sprite myrtleDeath;
    public Sprite UnitedWay;
    public Sprite foxDonation;
    public Sprite Surprises;
    public Sprite woldsonPic;

    // Use this for initialization
    void Start () {
        int billboardNumber = PlayerPrefs.GetInt("billboardNumber");

        //mainCamera.transform.position = new Vector3(42, 11, 19); //starting postion
        //mainCamera.transform.position = new Vector3(30, 11, 19); //for 0
        //mainCamera.transform.position = new Vector3(-30, 11, 19); //for 1
        //mainCamera.transform.position = new Vector3(-60, 11, 19); //for 2
        //mainCamera.transform.position = new Vector3(-120, 11, 19); //for 3
        //mainCamera.transform.position = new Vector3(-160, 11, 19); //for 4
        //mainCamera.transform.position = new Vector3(-190, 11, 19); //for 5
        //mainCamera.transform.position = new Vector3(-240, 11, 19); //for 6

        if (billboardNumber == 0)
        {
            title.text = "Edwidge Woldson";
            date.text = "1886-1966";
            description.text = "This text states that Edwidge Woldson (1886-1966) was born to the pioneer Milot family in Montana and had 12 siblings. She married railroad contractor Martin Woldson at 22 before they moved to Spokane, where Martin helped introduce the Great Northern Railroad. The couple had two children, Frances and Myrtle, eventually settling in a mansion on Sumner Avenue overlooking the city. Along with her daughter Myrtle, Edwidge oversaw the renovation of the home into a magnificent showplace with extensive gardens. To honor her mother, Myrtle later funded the restoration of the Moore-Turner Heritage Gardens in 2005. Culture and Spokane - This article's discussion of Edwidge's French roots contributes to the conversation about Myrtle's taste for French culture. Similarly, Edwidge's fondness for gardening was passed down to Myrtle, who brought aesthetic beauty to Spokane through the Moore - Heritage Gardens.Edwidge and Martin's move to Spokane was important as they added to the business-hub/melting pot culture that burgeoned in the city, which was a major railroad center. Martin thrived in this environment as a railroad contractor.";
            image.sprite = edwidge;
            PlayerPrefs.SetInt("cameraPosition", -30);

        } else if (billboardNumber == 1) {
            title.text = "Donation to United Way";
            date.text = "October 15, 1956";
            description.text = "This resource indicates that Martin and Edwige Woldson were generous philanthropists and made a $250 donation to the United Way in 1956.";
            image.sprite = UnitedWay;
            PlayerPrefs.SetInt("cameraPosition", 30);
        }
        else if (billboardNumber == 2) {
            title.text = "Myrtle's gift to Fox";
            date.text = "March 22, 2007";
            description.text = "This Spokesman Review article states that Myrtle (previously the anonymous donor for 6 years) confirmed her gift of $3 million to the Fox Theater, which as a result will be appropriately named after her music-loving father, Martin Woldson. According to the article, Myrtle also gave $1.2 mil+ to the restoration of Moore-Turner Heritage Garden in Pioneer Park near her home on Sumner. Pete Moye, president of the Fox Theater organization, said her gift was wonderful because 'this is a hometown person putting their money into reviving this part of town'. Culture and Spokane - Pete Moye's words show that it was important to recognize Spokane citizens' dedication to the community. Myrtle's six year anonymity shows that humility was a valued virtue, and her desire to name the theater after her father shows the importance of familial pride. Lastly, Myrtle helped fuel the communitys passion for the continued success of the arts in Spokane as well as the restoration of historical and cultural landmarks.";
            image.sprite = foxDonation;
            PlayerPrefs.SetInt("cameraPosition", -60);
        }
         else if (billboardNumber == 3) {
            title.text = "Philanthropist Woldson dies at 104";
            date.text = "April 11, 2014";
            description.text = "This newspaper article announces that Myrtle, a prominent Spokane philanthropist, passed in her home at age 104. She was responsible for donating $3M for the restoration of the Fox Theater in honor of her father's love for music, and for funding the restoration of the Moore-Turner Heritage Garden to honor her mother's love for gardening. In 2010, the Spokane Park Board voted to change the name of Pioneer Park to Edwidge Woldson Park to honor Myrtle's donation to the garden. Myrtle's personal representative and close friend Mark Danner said she was an accomplished businesswoman who \"died as she lived, with dignity and in privacy.\" The accompanying obituary includes a black and white portrait of the elderly Myrtle Woldson and states that Myrtle was survived by nephews and cousins, extended family Mark Danner, and close friend Mayor David Condon. The text mentions her donations to the Fox Theater and Moore-Turner Heritage Gardens as well as her embodiment of the \"Age of Elegance.\" Funeral and mass arrangements are detailed at the conclusion of the obituary. The mass was held at St. Aloysius church on Gonzaga's campus. Culture and Spokane - Myrtle shaped the Spokane landscape physically and artistically as she brought high-quality music to the city through the Martin Woldson Theater at the Fox and contributed to the restoration of the aesthetic Moore - Turner Heritage Gardens.";
            image.sprite = myrtleDeath;
            PlayerPrefs.SetInt("cameraPosition", -120);

        } else if (billboardNumber == 4) {
            title.text = "Eulogy for Miss Woldson-Thayne McCulloh";
            date.text = "2014";
            description.text = "Thayne McCulloh begins his eulogy for Myrtle by outlining the era in which she grew up, the \"Age of Elegance.\" He then described how she was part of an inner circle of successful industrialist families in Spokane, the regional epicenter of mining, timber, agriculture, and culture. McCulloh continues by going deeper into their 20 year friendship, throughout which they met up many times to discuss the future of the city and GU. He also remembers her well-read nature and musical talent as well as her recognition of the importance of art and music. McCulloh comments that she witnessed crucial points in history such as the Depression and WWII, which combined with her father's railroad contractor insights aided her understanding of what leads to city growth. Myrtle's family and her independent decisions as a businesswoman played a direct role in the growth of Spokane, which she held a deep love for along with her parents. McCulloh then highlights Myrtle's sense of humor, love of surprising people, devotion to Zag basketball, and her incrementally more and more generous donation to GU Athletics. Overall, McCulloh remembers Myrtle as a quietly generous woman who cared deeply about her relationships and left behind a legacy of learning and love. Culture and Spokane - This source conveys that Myrtle brought growth, art, music, and education to Spokane through her special insight as a well - traveled, well - read businesswoman who lived through major US events such as WWII and the Depression.Her donations to GU and Spokane left behind a legacy of learning, creative expression, and love.";
            Destroy(image);
            PlayerPrefs.SetInt("cameraPosition", -160);
        } 
        else if (billboardNumber == 5)
        {
            title.text = "Surprises from Miss Woldson";
            date.text = "October 5, 2015";
            description.text = "This Gonzaga Magazine article begins by saying that Myrtle knew what she liked, and lists her fondness for silver, flowers, Gonzaga, art, music, and 20th century French furniture (all of which is very evident in photos of her home). Her love of French furniture is explained by the fact that Myrtle's mother is French. Going into more about Myrtle's family, the article states that Myrtle learned about the business world (usually men's talk, but it was fascinating to her) from her father and how to be an elegant lady from her mother. She put this knowledge into practice by purchasing land in Spokane and Seattle. After developing a multi-million dollar enterprise, Myrtle used the money to help revitalize Spokane with things like the Edwidge Woldson Park and Martin Woldson Theater at the Fox. Before her passing, she met with GU President Thayne McCulloh, and upon her death, she gave $55 million to GU for scholarships and a performing arts center. This gift became the largest in both Gonzaga and the state of Washington's history. Culture and Spokane - Myrtle's love of flowers, GU, music, and art is reflected in her philanthropy, which helps foster these loves in the Spokane community. Her French furniture in her home displays European influences on her tastes.";
            image.sprite = Surprises;
            PlayerPrefs.SetInt("cameraPosition", -190);
        }
        else if (billboardNumber == 6)
        {
            title.text = "Eulogy for Miss Woldson-Thayne McCulloh";
            date.text = "2014";
            description.text = "Thayne McCulloh begins his eulogy for Myrtle by outlining the era in which she grew up, the \"Age of Elegance.\" He then described how she was part of an inner circle of successful industrialist families in Spokane, the regional epicenter of mining, timber, agriculture, and culture. McCulloh continues by going deeper into their 20 year friendship, throughout which they met up many times to discuss the future of the city and GU. He also remembers her well-read nature and musical talent as well as her recognition of the importance of art and music. McCulloh comments that she witnessed crucial points in history such as the Depression and WWII, which combined with her father's railroad contractor insights aided her understanding of what leads to city growth. Myrtle's family and her independent decisions as a businesswoman played a direct role in the growth of Spokane, which she held a deep love for along with her parents. McCulloh then highlights Myrtle's sense of humor, love of surprising people, devotion to Zag basketball, and her incrementally more and more generous donation to GU Athletics. Overall, McCulloh remembers Myrtle as a quietly generous woman who cared deeply about her relationships and left behind a legacy of learning and love. Culture and Spokane - This source conveys that Myrtle brought growth, art, music, and education to Spokane through her special insight as a well - traveled, well - read businesswoman who lived through major US events such as WWII and the Depression.Her donations to GU and Spokane left behind a legacy of learning, creative expression, and love.";
            image.sprite = woldsonPic;
            PlayerPrefs.SetInt("cameraPosition", -240);
        }
        else if (billboardNumber == 7)
        {
            title.text = "Eulogy for Miss Woldson-Thayne McCulloh";
            date.text = "2014";
            description.text = "Thayne McCulloh begins his eulogy for Myrtle by outlining the era in which she grew up, the \"Age of Elegance.\" He then described how she was part of an inner circle of successful industrialist families in Spokane, the regional epicenter of mining, timber, agriculture, and culture. McCulloh continues by going deeper into their 20 year friendship, throughout which they met up many times to discuss the future of the city and GU. He also remembers her well-read nature and musical talent as well as her recognition of the importance of art and music. McCulloh comments that she witnessed crucial points in history such as the Depression and WWII, which combined with her father's railroad contractor insights aided her understanding of what leads to city growth. Myrtle's family and her independent decisions as a businesswoman played a direct role in the growth of Spokane, which she held a deep love for along with her parents. McCulloh then highlights Myrtle's sense of humor, love of surprising people, devotion to Zag basketball, and her incrementally more and more generous donation to GU Athletics. Overall, McCulloh remembers Myrtle as a quietly generous woman who cared deeply about her relationships and left behind a legacy of learning and love. Culture and Spokane - This source conveys that Myrtle brought growth, art, music, and education to Spokane through her special insight as a well - traveled, well - read businesswoman who lived through major US events such as WWII and the Depression.Her donations to GU and Spokane left behind a legacy of learning, creative expression, and love.";
            image.sprite = woldsonPic;
            PlayerPrefs.SetInt("cameraPosition", -260);
        }
        else if (billboardNumber == 8) //This is the video view
        {
            title.text = "Eulogy for Miss Woldson-Thayne McCulloh";
            date.text = "2014";
            description.text = "Thayne McCulloh begins his eulogy for Myrtle by outlining the era in which she grew up, the \"Age of Elegance.\" He then described how she was part of an inner circle of successful industrialist families in Spokane, the regional epicenter of mining, timber, agriculture, and culture. McCulloh continues by going deeper into their 20 year friendship, throughout which they met up many times to discuss the future of the city and GU. He also remembers her well-read nature and musical talent as well as her recognition of the importance of art and music. McCulloh comments that she witnessed crucial points in history such as the Depression and WWII, which combined with her father's railroad contractor insights aided her understanding of what leads to city growth. Myrtle's family and her independent decisions as a businesswoman played a direct role in the growth of Spokane, which she held a deep love for along with her parents. McCulloh then highlights Myrtle's sense of humor, love of surprising people, devotion to Zag basketball, and her incrementally more and more generous donation to GU Athletics. Overall, McCulloh remembers Myrtle as a quietly generous woman who cared deeply about her relationships and left behind a legacy of learning and love. Culture and Spokane - This source conveys that Myrtle brought growth, art, music, and education to Spokane through her special insight as a well - traveled, well - read businesswoman who lived through major US events such as WWII and the Depression.Her donations to GU and Spokane left behind a legacy of learning, creative expression, and love.";
            image.sprite = woldsonPic;
            PlayerPrefs.SetInt("cameraPosition", -260);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
