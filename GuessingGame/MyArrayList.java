// Christoph Van Jaarsveld 50143956
public class MyArrayList<E>
{
  private int size; // Number of elements in the list
  private E[] data;

  /** Create an empty list */
  public MyArrayList()
  {
       data = (E[])new Object[100]; // cannot create array of generics
       size = 0; // Number of elements in the list
  }

  public void add(int index, E e)
  {
    // Ensure the index is in the right range
    if (index < 0 || index > size)
      throw new IndexOutOfBoundsException("Index: " + index + ", Size: " + size);

    // Move the elements to the right after the specified index
    for (int i = size - 1; i >= index; i--)
      data[i + 1] = data[i];

    // Insert new element to data[index]
    data[index] = e;

    // Increase size by 1
    size++;
  }

  public boolean contains(Object e)
  {
    for (int i = 0; i < size; i++)
      if (e.equals(data[i])) return true;

    return false;
  }

  public E get(int index)
  {
    if (index < 0 || index >= size)
      throw new IndexOutOfBoundsException("Index: " + index + ", Size: " + size);

    return data[index];
  }

  public E remove(int index)
  {
    if (index < 0 || index >= size)
      throw new IndexOutOfBoundsException("Index: " + index + ", Size: " + size);

    E e = data[index];

    // Shift data to the left
    for (int j = index; j < size - 1; j++)
      data[j] = data[j + 1];

    data[size - 1] = null; // This element is now null

    // Decrement size
    size--;

    return e;
  }

  public String toString()
  {
    String result = "[";
    for (int i = 0; i < size; i++)
    {
      result += data[i];
      if (i < size - 1) result += ", ";
    }
    return result + "]";
  }

  public void clear()
  {
      for (int i = 0; i < size; i++)
        data[i] = null;

      size = 0;
  }

  public int getsize()
  {
    return size;
  }

  public void swap(int index1, int index2)
  {
    if (index1 < 0 || index1 >= size || index2 < 0 || index2 >= size)
      throw new IndexOutOfBoundsException();

    E temp = data[index1];
    data[index1] = data[index2];
    data[index2] = temp;
  }
}