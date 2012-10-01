/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of Desig__StatAST.
	/// </summary>
	public class DesigplusStatAST : StatementAST
	{
		public DesignatorAST designator;
		
		public DesigplusStatAST(DesignatorAST desig)
		{
			designator=desig;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigplusStatAST(this,arg);
		}
	}
}
