/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 30/09/2012
 * Time: 03:49 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of PrettyPrintAST.
	/// </summary>
	public class PrettyPrintAST// : Visitor
	{
		public PrettyPrintAST()
		{
		}
		
		
		public void imprimir(AST raiz)
        {
          raiz.visit(this,new Integer(0));
        }
		
		
		//Imprime separadores
		public void printtab(int n)
        {
          for(int num=n; num != 0; num--)
          {  Console.WriteLine("+++");
             Console.WriteLine(">");
          }
        }
		
		
		
		//Métodos para imprimir AST
	/*	
	  public Object VisitProgramBasic(ProgramBasic c, Object arg)
      {
        int numaux = ((Integer)arg).intValue();
        printtab(numaux);
    
        System.out.println(c.getClass().getName());
        if (c.dec!=null)
        c.dec.visit(this,new Integer(numaux+1));
        else
         {
           printtab(numaux+1);
           System.out.println("NULL");
         }
        if (c.sta!=null)
           c.sta.visit(this,new Integer(numaux+1));
        else
        {
         printtab(numaux+1);
         System.out.println("NULL");
        }
         return null;
         */
  }
		
		
}

