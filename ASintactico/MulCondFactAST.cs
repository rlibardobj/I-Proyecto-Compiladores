/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:16 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulCondFact.
	/// </summary>
	public class MulCondFactAST:CondTermAST
	{
		CondTermAST condfact;
		CondTermAST condfacts;
		public MulCondFactAST(CondTermAST cond, CondTermAST conds)
		{
			condfact=cond;
			condfacts=conds;
		}
	}
}
