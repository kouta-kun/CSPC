using System;
using System.Collections.Generic;
namespace SExpr {
    /// <remarks>
    /// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
    /// </remarks>
    public class ListNode : Node {
	private List<Node> value;
	private bool _executionList = false;
	public bool executionList {
	    get { return _executionList; }
	}
	public ListNode(bool exec) {
	    this._executionList = exec;
	    this.value = new List<Node>();
	}
	public ListNode(List<Node> list, bool exec) {
	    this.value = list;
	    this._executionList = exec;
	}
	public override Node getCopy() {
	    return new ListNode(this.value, this.executionList);
	}
	public void addNode(Node i) {
	    this.value.Add(i);
	}
	public Node getNode(int i) {
	    return this.value[i];
	}
	public int getSize() {
	    return this.value.Count;
	}
	public override string ToString() {
	    string ret = "(";
	    for(int i = 0; i < this.getSize(); i++) {
		ret += this.getNode(i);
		if(i != this.getSize()-1) ret += ",";
	    }
	    return ret + ")";
	}
    };
};
