/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:50 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of DesigPAStatAST.
	/// </summary>
	public class DesigPAStatAST : StatementAST
	{
		public DesignatorAST designator;
	    public ActParsAST expresion;
	    
		public DesigPAStatAST(DesignatorAST desig, ActParsAST expr)
		{
			designator=desig;
			expresion=expr;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigPAStatAST(this,arg);
		}
	}
}
