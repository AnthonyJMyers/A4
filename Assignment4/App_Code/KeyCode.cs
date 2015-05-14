using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
 
 
/// <summary> 
/// Summary description for KeyCode 
/// </summary> 
public class KeyCode 
{ 
public int GetKeyCode() 
   { 
    Random rand = new Random(); 
    return rand.Next(1000000, 9999999); 
   } 
 } 
