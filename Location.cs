internal class Location {
    private int _tokenNum; 
    private string _resource;
        
    private int[] _pipCountArray = new int[]{0, 0, 1, 2, 3, 4, 5, 0, 5, 4, 3, 2, 1};
    private string _id;
    private bool _isDuplicate = false;

    public Location(int tokenNum, string resource) {
        _tokenNum = tokenNum; 
        _resource = resource;

            
        _id = "a";
    }
    public int Token {
        get {return  _tokenNum; } set { _tokenNum = value; }
    }

    public string Resource {
        get {return _resource;} set { _resource = value; }
    }

    public bool IsDuplicate {
        get {return _isDuplicate;} set { _isDuplicate = value; }
    }

    public string ID {
        get {return _id;  } set { _id = value; } 
    }

    public string LocationToString() {
        string subID = "";
        if (_isDuplicate) {subID = _id;}
        string response = $"{_resource}-{_tokenNum}{subID}"; 
        return response;
    }//END METHOD

    public int GetPipInfo() {
        return _pipCountArray[_tokenNum];
    }
}//END CLASS