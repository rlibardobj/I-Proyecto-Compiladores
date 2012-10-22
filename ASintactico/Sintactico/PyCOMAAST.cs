/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 30/09/2012
 * Time: 11:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of PyCOMAAST.
	/// </summary>
	public class PyCOMAAST : TerminalesAST
	{
		Token value;
		public PyCOMAAST(Token valor)
		{
			value=valor;
		}
		
		public override object visit(Visitor v,object arg){
			return null;
		}
	}
}
