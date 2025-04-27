using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
   private string correctGermOrder = "BlueRedGreen";
   private string enterGermOrder = "";
   
   private int amountOfGerms = 3;
   private int  currentAmountOfGerm = 0;
   
   [SerializeField] private Germ[] germs;
   
   [SerializeField] private Animator openBoxAnimator;

  public void GermSelect(Germ germ)
   {
      enterGermOrder += germ.name;
      currentAmountOfGerm += 1;
      
      germ.ChangeEmissionColor(true);
      
      if(currentAmountOfGerm == amountOfGerms)
         CompareGermsOrder();
   }

   void CompareGermsOrder()
   {
      if (enterGermOrder == correctGermOrder)
      {
         OpenBox();
      }
      else
      {
         ResetGame();
      }
   }

   public void OpenBox()
   {
      openBoxAnimator.SetTrigger("Open");
   }

   public void ResetGame()
   {
      currentAmountOfGerm = 0;
      enterGermOrder = "";

      foreach (var germ in germs)
      {
         germ.ChangeEmissionColor(false);
      }
   }
}
