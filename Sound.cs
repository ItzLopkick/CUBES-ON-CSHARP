using NAudio.Wave;

public class Sound
{
    private WaveOutEvent waveOut;
    private Mp3FileReader reader;

    public void PlaySound(string audio,float volume)
    {
        waveOut?.Stop();
        waveOut?.Dispose();
        reader?.Dispose();

        reader = new Mp3FileReader(audio);
        waveOut = new WaveOutEvent();

        waveOut.Init(reader);
        waveOut.Volume = volume;
        waveOut.Play();
    }

    public void PlayLoop(string audio,float volume)
    {
        waveOut?.Stop();
        waveOut?.Dispose();
        reader?.Dispose();

        reader = new Mp3FileReader(audio);
        waveOut = new WaveOutEvent();

        waveOut.Init(reader);

        waveOut.PlaybackStopped += (s, e) =>
        {
            reader.Position = 0;
            waveOut.Play();
        };
        waveOut.Volume = volume;
        waveOut.Play();
    }

    public void Stop()
    {
        waveOut?.Stop();
    }
}
