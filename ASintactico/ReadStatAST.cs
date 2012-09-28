/*
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
	/// Description of ReadStatAST.
	/// </summary>
	public class ReadStatAST : StatementAST
	{
		DesignatorAST designator;
		public ReadStatAST(DesignatorAST desig)
		{
			designator=desig;
		}
	}
}
