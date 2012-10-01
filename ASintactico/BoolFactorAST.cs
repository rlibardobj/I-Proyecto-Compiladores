/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:47 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of BoolFactorAST.
	/// </summary>
	public class BoolFactorAST:FactorAST
	{
		public BOOLAST boolf;
		
		public BoolFactorAST(BOOLAST bol)
		{
			boolf=bol;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitBoolFactorAST(this,arg);
		}
	}
}
