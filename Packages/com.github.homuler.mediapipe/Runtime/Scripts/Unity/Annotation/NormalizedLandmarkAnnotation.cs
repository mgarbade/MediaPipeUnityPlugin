using UnityEngine;

namespace Mediapipe.Unity {
  public class NormalizedLandmarkAnnotation : Annotation<NormalizedLandmark>, I3DAnnotatable {
    [SerializeField] Color color = Color.red;
    [SerializeField] float radius = 15.0f;
    [SerializeField] bool visualizeZ = false;

    void OnEnable() {
      ApplyRadius(radius);
      SetColor(color);
    }

    void OnDisable() {
      ApplyRadius(0.0f);
    }

    public void SetRadius(float radius) {
      this.radius = radius;
      ApplyRadius(radius);
    }

    public void SetColor(Color color) {
      this.color = color;
      GetComponent<Renderer>().material.color = color;
    }

    public void VisualizeZ(bool flag = true) {
      this.visualizeZ = flag;
      Redraw();
    }

    protected override void Draw(NormalizedLandmark target) {
      transform.localPosition = CoordinateTransform.GetLocalPosition(GetAnnotationLayer(), target, isMirrored, !visualizeZ);
      // TODO: annotate visibility
    }

    void ApplyRadius(float radius) {
      transform.localScale = radius * Vector3.one;
    }
  }
}
