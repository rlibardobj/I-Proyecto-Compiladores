/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of BreakStatAST.
	/// </summary>
	public class BreakStatAST : StatementAST
	{
		public BreakStatAST()
		{
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitBreakStatAST(this,arg);
		}
	}
}
