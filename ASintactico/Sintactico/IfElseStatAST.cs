/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of IfElseStatAST.
	/// </summary>
	public class IfElseStatAST : StatementAST
	{
		
		public StatementAST ifstatement,elsestatement;
		public ConditionsAST condicion;
		
		public IfElseStatAST(StatementAST ifs, StatementAST elses, ConditionsAST cond)
		{
			condicion=cond;
			ifstatement=ifs;
			elsestatement=elses;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitIfElseStatAST(this,arg);
		}
	}
}
