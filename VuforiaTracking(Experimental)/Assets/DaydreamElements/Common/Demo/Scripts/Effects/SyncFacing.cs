// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace DaydreamElements.Common {

  using UnityEngine;
  using System.Collections;

  public class SyncFacing : MonoBehaviour {
    public Transform target;
    private Vector3 targetPos;
    public float speed = 1.0f;

    void OnDrawGizmosSelected() {
      if (target == true) {
        transform.LookAt(target);
      }
      else {
        transform.LookAt(Vector3.zero);
      }
    }

    void Start() {
      if (target == true) {
        targetPos = target.position;
      }
      else {
        targetPos = Vector3.zero;
      }
    }

    void Update() {
        float dt = Time.deltaTime;
        if (target == true) {
          targetPos = target.position;
        }
        else {
          targetPos = Vector3.zero;
        }
        Vector3 relativePos = targetPos - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        Quaternion rotation = transform.rotation;
        rotation = Quaternion.Slerp(rotation, targetRotation, dt*speed);
        transform.rotation = rotation;
    }
  }
}
