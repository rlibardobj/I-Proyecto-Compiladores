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
	/// Description of DesigPStatAST.
	/// </summary>
	public class DesigPStatAST : StatementAST
	{
		DesignatorAST designator;
		public DesigPStatAST(DesignatorAST desig)
		{
			designator = desig;
		}
	}
}
