<?php

declare(strict_types = 1);

/**
 * Problem:
 * Oft ändernde Klasse
 */
class PayPalV1
{
    /**
     * @var int
     */
    private $amount = 0;

    public function setPayment(int $amount)
    {
        $this->amount = $amount;
    }
    public function sendPayment()
    {
        echo 'Paying via PayPal: '. $this->amount;
    }
}

class PayPalV2
{
    public function sendPayment(int $amount)
    {
        echo 'Paying via PayPal: '. $amount;
    }
}

/**
 * Lösung:
 * Interface für jeden Adapter
 */
interface PaymentInterface
{
    public function pay(int $amount);
}

class PaypalAdapter implements PaymentInteface
{
    /**
     * @var PayPalV2
     */
    private $paypal;

    public function __construct(PayPalV2 $paypal)
    {
        $this->paypal = $paypal;
    }

    public function pay(int $amount)
    {
        $this->paypal->sendPayment($amount);
    }
}
