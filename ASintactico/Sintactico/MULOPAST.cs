/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 08:28 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MULOPAST.
	/// </summary>
	public class MULOPAST : TerminalesAST
	{
		public Token value;
		
		public MULOPAST(Token valor)
		{
			value=valor;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMULOPAST(this,arg);
		}
	}
}
