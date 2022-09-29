sudo apt -y update 
sudo apt -y install vim 


# prepare mediapipe
cd ..
sudo cp -r mp_v16_mntd mp_v16
sudo chown -R mediapipe:mediapipe mp_v16


# update bazel
cd mp_v16
echo "5.2.0" > .bazelversion
cd ..

# make WORKSPACE file use local mediapipe
cd mediapipe
# git apply Assets/compile_with_local_mp.patch

# apply patches
cd ..
cd mp_v16
git apply -p1 ../mediapipe/third_party/mediapipe_opencv.diff
git apply -p1 ../mediapipe/third_party/mediapipe_workaround.diff
git apply -p1 ../mediapipe/third_party/mediapipe_visibility.diff
git apply -p1 ../mediapipe/third_party/mediapipe_model_path.diff
git apply -p1 ../mediapipe/third_party/mediapipe_extension.diff


# compile mpup
cd ..
cd mediapipe

echo "apply compile_with_local_mp.patch"
echo "then"
echo "execute this command manually (without sudo)"
echo "python build.py build --android fat --android_ndk_api_level 21 --solutions pose -vv --opencv cmake -v --linkopt=-s"

