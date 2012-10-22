/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 08:29 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ADDOPAST.
	/// </summary>
	public class ADDOPAST : TerminalesAST
	{
		public Token value;
		
		public ADDOPAST(Token valor)
		{
			value=valor;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitADDOPAST(this,arg);
		}
	}
}
