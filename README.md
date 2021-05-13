# TwoCharacters
Remove Characters from a String you get an alternating string of two characters.  Took Days!

### Despite the summary on HackerRank, the object is not in fact to delete characters from the string.  I found out the best way was to create a 2d Array (like a grid) and place each character in its row and column, e.g.

      t
ttttttt
      t
      t
      
in this example, if you end up with the same character twice in a grid cell ('tt'), you have to  invalidate the cell, so I placed a number.  This way, the validation function would not identify it as a potential alternating string.

This grid method and entering a number to invalidate a cell speeds up the algorithm and prevents slowdowns when parsing very large strings
