using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;
    [SerializeField] PlaySoundFX markerSoundFX;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;

    public bool useMarker;
    
    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    void Update()
    {
        if (useMarker == true)
        {
            Draw();
        }
    }

    public void UseMarker(bool use)
    {
        useMarker = use;
    }

    public void Draw()
    {
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.GetComponent<Whiteboard>())
            {
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x) return;

                if (_touchedLastFrame)
                {
                    markerSoundFX.Play();
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot;
                    
                    _whiteboard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }
        else
        {
            markerSoundFX.Stop();
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }

    private void OnDrawGizmos()
    {
        if (useMarker)
        {
            Gizmos.color = Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight) ? Color.green : Color.red;
            Gizmos.DrawRay(_tip.position, transform.up);
        }
    }
}
