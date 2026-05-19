using System;
using System.IO;
using NAudio.Wave;

namespace CyberTimes_ChatBot_Part2
{
    // AudioRecorder is a small helper class that records microphone input to a WAV file.
    // It uses the NAudio library to capture audio and write it to disk.
    // This class is simple so beginners can see how recording works.
    public class AudioRecorder : IDisposable
    {
        // waveIn captures audio from the default input device (microphone).
        private WaveInEvent? waveIn;
        // writer writes WAV data into a file on disk.
        private WaveFileWriter? writer;
        // OutputFile stores the path of the current recording file.
        public string? OutputFile { get; private set; }

        // StartRecording opens the microphone and starts writing to the given outputFile.
        // Input: outputFile - full path where the WAV will be saved.
        public void StartRecording(string outputFile)
        {
            // Stop any previous recording to be safe.
            StopRecording();

            // Remember the file path for later use.
            OutputFile = outputFile;

            // Create a new recorder using the default microphone.
            waveIn = new WaveInEvent();
            // Use a common format: 16 kHz mono. This is small and good for voice notes.
            waveIn.WaveFormat = new WaveFormat(16000, 1);

            // Create a WaveFileWriter that writes WAV audio to disk.
            writer = new WaveFileWriter(outputFile, waveIn.WaveFormat);

            // When audio data is available, write it to disk in the OnDataAvailable handler.
            waveIn.DataAvailable += OnDataAvailable;

            // Start capturing audio from the microphone.
            waveIn.StartRecording();
        }

        // OnDataAvailable is called by NAudio whenever new audio bytes are ready.
        // We simply forward those bytes to the WAV file writer.
        private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            // If writer is not ready, do nothing.
            if (writer == null) return;
            // Write the captured audio bytes into the WAV file.
            writer.Write(e.Buffer, 0, e.BytesRecorded);
            // Flush to keep the file updated on disk.
            writer.Flush();
        }

        // StopRecording closes the microphone and finalizes the WAV file.
        public void StopRecording()
        {
            // If waveIn was created, stop and dispose it.
            if (waveIn != null)
            {
                waveIn.DataAvailable -= OnDataAvailable;
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
            }
            // If writer was created, dispose it to finish the WAV header.
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }

        // Dispose implements IDisposable so callers can use 'using' or call Dispose.
        // It simply calls StopRecording to clean up resources.
        public void Dispose()
        {
            StopRecording();
        }
    }
}
