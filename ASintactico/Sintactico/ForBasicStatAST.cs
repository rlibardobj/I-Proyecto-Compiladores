﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:46 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ForBasicStatAST.
	/// </summary>
	public class ForBasicStatAST : StatementAST
	{
		public ExprAST expresion;
		public StatementAST statement;
		public ForBasicStatAST(ExprAST expr, StatementAST sta)
		{
			expresion=expr;
			statement=sta;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitForBasicStatAST(this,arg);
		}
	}
}
