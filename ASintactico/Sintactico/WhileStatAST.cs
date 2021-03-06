﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of WhileStatAST.
	/// </summary>
	public class WhileStatAST : StatementAST
	{
		public ConditionsAST condicion;
		public StatementAST statement;
		
		public WhileStatAST(ConditionsAST cond, StatementAST sta)
		{
			condicion=cond;
			statement=sta;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitWhileStatAST(this,arg);
		}
	}
}
