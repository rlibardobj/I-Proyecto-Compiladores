/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 15/09/2012
 * Time: 07:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace ASintactico
{
	/// <summary>
	/// Description of Prueba.
	/// </summary>
	public class Prueba
	{
    	public static void Main(string[] argv)
    	{
    		//StreamReader archivo=new StreamReader("prueba.txt");
    		//Console.WriteLine(archivo.ReadToEnd());
    	/*parser parsing = new parser(new Scanner(new StreamReader(Console.ReadLine())));
    	ProgramAST arbol;
    	arbol=parsing.parseProgram();
    	Console.WriteLine("IMPRESIÓN DEL ÁRBOL:");
        PrettyPrintAST instancia = new PrettyPrintAST();
        instancia.imprimir(arbol);
        Console.WriteLine();
        Console.Write("FIN DE IMPRESIÓN");
    	Console.ReadLine();*/
    	Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
    	Application.Run(new Principal());
    	
	}
}
}
