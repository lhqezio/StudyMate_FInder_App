using System;
using System.Text.RegularExpressions;

//This class makes sure that all the inputs entered by the user are valid
namespace StudyMate
{

    public class UserInput{

        private string __regex;
        public UserInput(string regex) //Based  on the type 
        {
            this.__regex = regex;

        }  

        public string ReadLine(){
            string? userInput;
            bool valid = false;
            do{
                userInput = Console.ReadLine(); 
                if(Regex.IsMatch(userInput!, this.__regex)){  
                    valid = true;
                }
                else{
                    Console.WriteLine("Wrong input. Try Again");
                }                
            } while (!valid);
            return userInput!;
        }     
    }
  
}