/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:15 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnCondFact.
	/// </summary>
	public class UnCondFactAST:CondTermAST
	{
		public CondFactAST condfact;
		
		public UnCondFactAST(CondFactAST cond)
		{
			condfact=cond;
		}
		
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnCondFactAST(this,arg);
		}
	}
}
