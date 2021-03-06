﻿/*
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
	/// Description of DesigEStatAST.
	/// </summary>
	public class DesigEStatAST : StatementAST
	{
		public DesignatorAST designator;
		public ExprAST expresion;
		
		public DesigEStatAST(DesignatorAST desig, ExprAST expr)
		{
			designator=desig;
			expresion=expr;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigEStatAST(this,arg);
		}
	}
}
