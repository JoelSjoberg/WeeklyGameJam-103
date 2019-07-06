
using UnityEngine;
using UnityEngine.UI;

public class drawBufferComs : MonoBehaviour
{

    [SerializeField] Sprite left, right, up, down, halt, skip, border, inLoop, r, w, l, it;

    [SerializeField]movePlayer player;


    [SerializeField]Image reader, writer, Loop, Iter;
    Vector2 readerPosition, writerPosition, iterPosition, loopPosition;


    float x_pos = 25, y_pos = 25, increment = 50, img_dim = 40;


    private void OnGUI()
    {
        System.Action[] buffer = player.getBuffer();
        for (int i = 0; i < gameMaster.memory; i++)
        {
            GUI.DrawTexture(new Rect(x_pos + (i * increment), y_pos, img_dim, img_dim), border.texture);
            if (buffer[i] != null)
            {
                if ((i < player.getLoopPoint() && i >= player.getIterPoint()) || (i >= player.getLoopPoint() && i < player.getIterPoint()))
                {
                    GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), inLoop.texture);
                }



                if (buffer[i].Method.Name == "moveLeft") GUI.DrawTexture(new Rect(x_pos + 5 +(i * increment), y_pos, img_dim, img_dim), left.texture);
                else if(buffer[i].Method.Name == "moveRight") GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), right.texture);
                else if (buffer[i].Method.Name == "moveUp") GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), up.texture);
                else if (buffer[i].Method.Name == "moveDown") GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), down.texture);
                else if (buffer[i].Method.Name == "skipMove") GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), skip.texture);
                else if (buffer[i].Method.Name == "halt") GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), halt.texture);

                if (i == player.getReader()) GUI.DrawTexture(new Rect(x_pos + 5 + (i * increment), y_pos, img_dim, img_dim), r.texture);//{ readerPosition = new Vector2(x_pos + 5 + (i * increment), y_pos); }

            }
        }
    }

    private void Start()
    {
        readerPosition = new Vector2(0, 0);
        writerPosition = new Vector2(0, 0);
        loopPosition = new Vector2(0, 0);
        iterPosition = new Vector2(0, 0);
    }

    private void Update()
    {
        // reader.rectTransform.localPosition = Vector2.Lerp(reader.rectTransform.localPosition, readerPosition, 0.5f);
        // writer.rectTransform.anchoredPosition = Vector2.Lerp(writer.rectTransform.anchoredPosition, writerPosition, 0.5f);
        // Loop.rectTransform.anchoredPosition = Vector2.Lerp(Loop.rectTransform.anchoredPosition, loopPosition, 0.5f);
        // Iter.rectTransform.anchoredPosition = Vector2.Lerp(Iter.rectTransform.anchoredPosition, iterPosition, 0.5f);
    }
}
