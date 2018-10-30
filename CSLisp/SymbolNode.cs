using System;
namespace SExpr {
    /// <remarks>
    /// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
    /// </remarks>
    public class SymbolNode : Node {
	public string symbol;
	public SymbolNode(string sym) {
	    this.symbol = sym;
	}
	public override Node getCopy() {
	    return new SymbolNode(this.symbol);
	}
	public override string ToString() {
	    return "'" + this.symbol;
	}
    };
};
