using System.Device.Gpio;

namespace JarvisWizard.Services
{
    public class GpioRaspberryService
    {
        private readonly int _pin = 18;
        private readonly GpioController _gpioController;

        public GpioRaspberryService() {
            _gpioController = new GpioController();
        }

        public void Rele(bool estado)
        {
            try
            {
                PinStatus(_pin);

                _gpioController.OpenPin(_pin, PinMode.Output);
                _gpioController.Write(_pin,estado ? PinValue.High : PinValue.Low);
                _gpioController.ClosePin(_pin);
            }
            catch
            {
                throw;
            }
        }

        public void PinStatus(int pin)
        {
            if (!_gpioController.IsPinOpen(pin))
            {
                _gpioController.OpenPin(pin, PinMode.Output);
            }
            else
            {
                _gpioController.ClosePin(pin);
            }
        }
    }
}
