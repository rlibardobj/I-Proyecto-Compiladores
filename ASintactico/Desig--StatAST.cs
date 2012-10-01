/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:49 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of Desig__StatAST.
	/// </summary>
	public class DesigminusStatAST : StatementAST
	{
		public DesignatorAST designator;
		
		public DesigminusStatAST(DesignatorAST des)
		{
			designator=des;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigminusStatAST(this,arg);
		}
	}
}
