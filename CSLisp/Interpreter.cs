using System;
using System.Collections.Generic;
namespace SExpr {
/// <remarks>
/// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
/// </remarks>
    public class Interpreter {
	public static void Main(string[] args) {
	    Interpreter f = new Interpreter();
	    while(f.running) {
		Console.Write(">>");
		var lineIn = Console.ReadLine();
		if(lineIn == null) break;
		var parsedLine = Parser.ParseString(lineIn);
		var res = f.RunFunction(parsedLine);
		Console.WriteLine("Result: " + res);
	    }
	}
	private Dictionary<string, Func<ListNode, Node>> functions =
	    new Dictionary<string, Func<ListNode, Node>>();
	private bool _running = true;
	public bool running {
	    get {
		return _running;
	    }
	}
	public bool IsFunction(Node i) {
	    if(i is SymbolNode sn)
		return functions.ContainsKey(sn.symbol);
	    return false;
	}
	public Node RunFunction(ListNode list) {
	    SymbolNode function = list.getNode(0) as SymbolNode;
	    if(!IsFunction(function)) return new StringNode(function + " is not a defined function in this interpreter");
	    ListNode arglist = new ListNode(false);
	    for(int i = 1; i < list.getSize(); i++)
	    {
		if(list.getNode(i) is ListNode ls) {
		    if(ls.executionList)
			arglist.addNode(this.RunFunction(ls));
		    else
			arglist.addNode(ls.getCopy());
		} else arglist.addNode(list.getNode(i).getCopy());
	    }
	    Node result = this.functions[function.symbol](arglist);
	    return result;
	}
	public Interpreter() {
	    functions["list"] = p => p.getCopy();
	    functions["^"] = p => {
		double r = (p.getNode(0) as NumberNode).value;
		for(int i = 1; i < p.getSize(); i++)
		    r = Math.Pow(r, (p.getNode(i) as NumberNode).value);
		return new NumberNode(r);
	    };
	    functions["+"] = p => {
		double r = (p.getNode(0) as NumberNode).value;
		for(int i = 1; i < p.getSize(); i++)
		    r += (p.getNode(i) as NumberNode).value;
		return new NumberNode(r);
	    };
	    functions["-"] = p => {
		double r = (p.getNode(0) as NumberNode).value;
		for(int i = 1; i < p.getSize(); i++)
		    r -= (p.getNode(i) as NumberNode).value;
		return new NumberNode(r);
	    };
	    functions["*"] = p => {
		double r = (p.getNode(0) as NumberNode).value;
		for(int i = 1; i < p.getSize(); i++)
		    r *= (p.getNode(i) as NumberNode).value;
		return new NumberNode(r);
	    };
	    functions["/"] = p => {
		double r = (p.getNode(0) as NumberNode).value;
		for(int i = 1; i < p.getSize(); i++)
		    r /= (p.getNode(i) as NumberNode).value;
		return new NumberNode(r);
	    };
	    functions["exit"] = p => {
		this._running = false;
		return null;
	    };
	}
    };
}
