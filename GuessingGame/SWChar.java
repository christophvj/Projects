// Christoph Van Jaarsveld 50143956
public class SWChar
{
    private char value;
    private boolean guessed;

    public SWChar(char val)
    {
      value = val;
      guessed = false;
    }

    public char getValue()
    {
       return value;
    }

    public boolean isGuessed()
    {
       return guessed;
    }

    public void Guessed()
    {
        guessed = true;
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof SWChar))
         return false;

        return value == ((SWChar)obj).getValue();
    }

    public String toString()
    {
        if(guessed)
          return "" + value;
        else
          return "_";
    }
}