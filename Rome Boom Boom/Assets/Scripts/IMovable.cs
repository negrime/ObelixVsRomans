
using UnityEngine;
namespace DefaultNamespace
{
    public interface IMovable
    {
        void Move();
        Vector3 Direction { get; set; }
    }
}