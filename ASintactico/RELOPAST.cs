/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 06:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of RELOPAST.
	/// </summary>
	public class RELOPAST : TerminalesAST
	{
		public string value;
		
		public RELOPAST(string valor)
		{
			value=valor;
		}
		public override object visit(Visitor v,object arg){
			return v.VisitRELOPAST(this,arg);
		}
	}
}
