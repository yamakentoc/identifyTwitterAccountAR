﻿using System;
using System.Collections.Generic;

[Serializable]
public class IdentifiedUsers {
    public int count;
    public List<User> users;
}

[Serializable]
public class User {
    public string name;
    public long id;
    public string profileImageURL;
    public float relevance;
}
